<?php

namespace App\Http\Controllers\API;

use Illuminate\Http\Request;
use App\Http\Controllers\Controller;
use App\Menu;
use Illuminate\Pagination\Paginator;


class MenuController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        return Menu::latest()->paginate(10);
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(Request $request)
    {
           $this->validate($request,[
            'name' => 'required|string|max:191',
        ]);

        return Menu::create([
            'name' => $request['name'],
            'isActive' => $request['isActive'],

        ]);
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, $id)
    {
        $menu = Menu::findOrFail($id);

           $this->validate($request,[
            'name' => 'required|string|max:191',
        ]);
        $menu->update($request->all());
        return ['message' => 'Updated the menu information'];
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {
        $menu = Menu::findOrFail($id);

        $menu->delete();
        return ['message' => 'Menu Deleted'];
    }

    public function search()
    {
        if ($search = \Request::get('q')) {
            $menus = Menu::where(function($query) use ($search){
                $query->where('name','LIKE',"%$search%")
                        ->orWhere('isActive','LIKE',"%$search%");
            })->paginate(20);
        }else{
            $menus = Menu::latest()->paginate(10);
        }
        return $menus;
    }

    public function statusZero(Request $request, $id) 
    {
          $menu = DB::table('menus')
                ->where('id', $menu->id)
                ->update(['isActive' => 1]);

        return ['message' => 'Menu status Updated'];
    }

    public function statusOne(Request $request, $id)
    {

        $menu = DB::table('menus')
                ->where('id', $menu->id)
                ->update(['isActive' => 0]);




        return ['message' => 'Menu status Updated'];
    }
}
