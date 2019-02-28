 <template>
    <div class="container">
        <div class="row mt-3">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <h3 class="card-title">Menu List</h3>
                        <div class="card-tools">
                            <button class="btn btn-success" @click="newModal">Add New
                                <i class="fas fa-user-plus fa-fw"></i> 
                            </button>
                        </div>
                    </div>
                    <!-- /.card-header -->
            <div class="card-body table-responsive p-0">
                <table   class="table table-hover">
                        <thead>
                        <tr>
                            <th>Sl.</th>
                            <th>Name</th>
                            <th>ID</th>
                            <th>Status</th>
                            <th>Action</th>
                        </tr>
                        </thead>
                        <tbody>
                    
                        <tr v-for="(menu, index) in menus.data" :key="menu.id" >
                            <td>{{ index + 1 }} </td>
                            <td>{{menu.name}}</td>
                            <td>{{menu.id}}</td>
                            <td>
                               
                                <span v-if="menu.isActive==1" class="label label-success"> Active </span>
                                <span v-else class="label label-danger"> Unactive </span>
                            </td>
                            <td> 
                                 
                                 <a v-if="menu.isActive==1" href="#"  @click="updateMenuZero(menu.id)">
                                    <i class="fas fa-thumbs-down red"></i>
                                </a>
                                <a v-else href="#" @click="updateMenuOne(menu.id)">
                                    <i class="fas fa-thumbs-up green"></i>
                                </a>
                                /
                                <a href="#" @click="editModal(menu)">
                                    <i class="fas fa-edit blue"></i>
                                </a>
                                /
                                <a href="#" @click="deleteMenu(menu.id)">
                                    <i class="fas fa-trash red"></i>
                                </a>
                            </td>
                        </tr>
                    </tbody>
                </table>
              </div>
              <!-- /.card-body -->
              <div class="card-footer">
              <pagination :data="menus" @pagination-change-page="getResults"></pagination>
              </div>
            </div>
        </div>
    </div>
        <!-- Modal -->
        <div class="modal fade" id="adNew" tabindex="-1" role="dialog" aria-labelledby="adNew" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 v-show="!editmode" class="modal-title" id="adNew">Add New Menu</h5>
                        <h5 v-show="editmode" class="modal-title" id="adNew">Update Menu's Info</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <form @submit.prevent="editmode ? updateMenu() : createMenu()" >
                    <div class="modal-body">
                        <div class="form-group">
                            <input v-model="form.name" type="text" name="name" placeholder="Name" 
                                class="form-control" :class="{ 'is-invalid': form.errors.has('name') }">
                            <has-error :form="form" field="name"></has-error>
                        </div>
                          <div class="form-group">
                            <label for="">Is Publish: </label>
                            <input v-model="form.isActive" type="checkbox" 
                             :class="{ 'is-invalid': form.errors.has('isActive') }">
                            <has-error :form="form" field="isActive"></has-error>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                        <button v-show="editmode" type="submit" class="btn btn-success">Update</button>
                        <button v-show="!editmode" type="submit" class="btn btn-primary">Create</button>
                    </div>
                </form>
                </div>
            </div>
        </div>
</div>
</template>

<script>
    export default {
        data() {
            return {
                editmode: false,
                menus : {},
                form: new Form({
                    id: '',
                    name : '',
                    isActive : ''

                })
            }
        },
        methods: {
            getResults(page = 1) {
                axios.get('api/menu?page=' + page)
                .then(response => {
                    this.menu = response.data;
                });
            },
            updateMenu(){
                 
                // console.log('Editing data');
                this.$Progress.start();
                this.form.put('api/menu/'+this.form.id)
                .then(() => {
                    // success
                    $('#adNew').modal('hide');
                    Swal.fire(
                        'Updated!',
                        'Information has been updated.',
                        'success'
                    )
                    this.$Progress.finish();
                    Fire.$emit('AfterCreate');
                })
                .catch(() => {
                    this.$Progress.fail();
                });
            },


               updateMenuOne(id){
                alert('One'+this.form.id);
                // console.log('Editing data');
                this.$Progress.start();
                this.form.get('api/isActiveMenu/'+this.form.id)
                .then(() => {
                    // success
                    $('#adNew').modal('hide');
                    Swal.fire(
                        'Updated!',
                        'Status has been updated.',
                        'success'
                    )
                    this.$Progress.finish();
                    Fire.$emit('AfterCreate');
                })
                .catch(() => {
                    this.$Progress.fail();
                });
            },
               updateMenuZero(id){
                alert('Zero'+this.form.id);
                console.log('Editing data');
                this.$Progress.start();
                this.form.get('api/isDeActiveMenu/'+this.form.id)
                .then(() => {
                    // success
                    $('#adNew').modal('hide');
                    Swal.fire(
                        'Updated!',
                        'Status has been updated.',
                        'success'
                    )
                    this.$Progress.finish();
                    Fire.$emit('AfterCreate');
                })
                .catch(() => {
                    this.$Progress.fail();
                });
            },
              editModal(menu){
                alert('msg'+this.form.id);
                this.editmode = true;
                this.form.reset();
                 $('#adNew').modal('show');
                 this.form.fill(menu);
            },
            newModal(){
 
                this.editmode = false;
                this.form.reset();
                 $('#adNew').modal('show');
            },
            deleteMenu(id){
                Swal.fire({
                    title: 'Are you sure?',
                    text: "You won't be able to revert this!",
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes, delete it!'
                    }).then((result) => {
                        // Send request to the server
                         if (result.value) {
                                this.form.delete('api/menu/'+id).then(()=>{
                                        Swal.fire(
                                        'Deleted!',
                                        'Your file has been deleted.',
                                        'success'
                                        )
                                    Fire.$emit('AfterCreate');
                                }).catch(()=> {
                                    Swal.fire("Failed!", "There was something wronge.", "warning");
                                });
                         }
                    })
            },
            loadMenus(){
                    axios.get("api/menu").then(({ data }) => (this.menus = data));

            },
                createMenu(){
                this.$Progress.start();

                this.form.post('api/menu')
                .then(()=>{
                    Fire.$emit('AfterCreate');

                    $('#adNew').modal('hide')

                   Toast.fire({
                        type: 'success',
                        title: 'Menu Created in successfully'
                    })

                    this.$Progress.finish();
                })
                .catch(()=>{
                })
            }
        },
        created() {
            Fire.$on('searching',() => {
                let query = this.$parent.search;
                axios.get('api/findMenu?q= ' + query)
                .then((data)=> {
                    this.menus = data.data
                })
                .catch(() => {

                })
            })
            this.loadMenus();
            Fire.$on('AfterCreate',() => {
                this.loadMenus();
            });
            // setInterval(() => this.loadmenu(), 3000);
        }
    }

</script>
