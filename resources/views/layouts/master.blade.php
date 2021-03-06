<style>
  
.searchbox
{
  display: flex;
  background-color: #2B85C1;
  padding: 10px;
  border-radius: 10px;
}

.searchbox input
{
  line-height: 30px;
  background: none;
  border: none;
  outline: none;
  color: white;
  font-size: 16px;  
  transition: all 0.5s;
  /*for animate*/
  width: 0px;
}
.searchbox:hover input
{
  width: 886px;
}
.searchbox input:focus
{
  width: 886px;
}
::placeholder 
{
  color: white;
}
.searchbox button 
{
  height: 30px;
  width: 30px;
  background: none;
  color: white;
  border: none;
  outline: none;
}

.searchbox:hover button 
{
  color: black;
  background-color: white;
  border-radius: 5%;
}

.searchbox input:focus + button
{
  color: black;
  background-color: white;
  border-radius: 5%;
}



</style>

<!DOCTYPE html>
<!--
This is a starter template page. Use this page to start your new project from
scratch. This page gets rid of all links and provides the needed markup only.
-->
<html lang="en">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <meta http-equiv="x-ua-compatible" content="ie=edge">
  <title>Admin | Dashboard</title>
  <!-- CSRF Token -->
  <meta name="csrf-token" content="{{ csrf_token() }}">


  <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css">
  <link rel="stylesheet" type="text/css" href="/css/app.css">
</head>
<body class="hold-transition sidebar-mini">
<div class="wrapper" id="app">

  <!-- Navbar -->
  <nav class="main-header navbar navbar-expand bg-white navbar-light border-bottom">
    <!-- Left navbar links -->
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" data-widget="pushmenu" href="#"><i class="fa fa-bars"></i></a>
      </li>
      <li class="nav-item d-none d-sm-inline-block">
        <a href="index3.html" class="nav-link">Home</a>
      </li>                    
    </ul>
    
      <ul class="navbar-nav" style="padding-right: 10px;">
      <li class="nav-item">
        <a href="{{ route('logout') }}" 
        onclick="event.preventDefault();
          document.getElementById('logout-form').submit();">

        <i class="nav-icon fa fa-power-off red" style="font-size: 18px;">
          
        </i>
        </a>
        <form id="logout-form" action="{{ route('logout') }}" method="POST" style="display: none;">
          @csrf
        </form>
      </li>
    </ul> 

    <!-- SEARCH FORM -->
      <div class="searchbox">
        <input name="search" @keyup="searchit" v-model="search" type="search" placeholder="Search" aria-label="Search">
         
          <button @click="searchit">
            <i class="fa fa-search"></i>
          </button> 
      </div>

  </nav>
  <!-- /.navbar -->

  <!-- Main Sidebar Container -->
  <aside class="main-sidebar sidebar-dark-primary elevation-4">
    <!-- Brand Logo -->
    <a href="index3.html" class="brand-link">
      <img src="{{ asset('images/logo.png') }}" alt="AdminLTE Logo" class="brand-image img-circle elevation-3"
           style="opacity: .8">
      <span class="brand-text font-weight-light">Admin Dashboard</span>
    </a>

    <!-- Sidebar -->
    <div class="sidebar">
      <!-- Sidebar user panel (optional) -->
      <div class="user-panel mt-3 pb-3 mb-3 d-flex">
        <div class="image">
          <img src="{{ asset('images/profile.png') }}" class="img-circle elevation-2" alt="User Image">
        </div>
        <div class="info">
          <a href="#" class="d-block">
            {{Auth::user()->name}}
          </a>
        </div>
      </div>

      <!-- Sidebar Menu -->
      <nav class="mt-2">
        <ul class="nav nav-pills nav-sidebar flex-column" data-widget="treeview" role="menu" data-accordion="false">
          <!-- Add icons to the links using the .nav-icon class
               with font-awesome or any other icon font library -->
          <li class="nav-item bg-dark">
            <router-link to="/dashboard" tag="a" class="nav-link"  active-class="active" exact>
              <i class="nav-icon fas fa-tachometer-alt teal"></i>
              <p>
                Dashboard
              </p>
            </router-link>
          </li>
          <li class="nav-item bg-dark">
            <router-link to="/developer" tag="a" class="nav-link"  active-class="active" exact>
              <i class="nav-icon fab fa-dev blue"></i>
              <p>
                  Developer
              </p>
            </router-link>
          </li>
          <li class="nav-item bg-dark">
            <router-link to="/profile" tag="a" class="nav-link"  active-class="active" exact>
              <i class="nav-icon fas fa-user green"></i>
              <p>
                 Profile
              </p>
            </router-link>
          </li>
          <li class="nav-item">
            <router-link to="/menu" tag="a" class="nav-link" active-class="active" exact>
              <i class="fas fa-home nav-icon cyan"></i>
              <p>
                Home/Menu
              </p>
            </router-link>
          </li>
            <!-- <ul class="nav nav-sidebar"> -->
              <li class="nav-item">
                <a href="#" class="nav-link">
                  <i class="fas fa-th-large nav-icon purple"></i>
                  <p>Manage Menu</p>
                </a>
              </li>
              <li class="nav-item">
                <router-link to="/users" class="nav-link">
                  <i class="fas fa-users nav-icon teal"></i>
                  <p>Users</p>
                </router-link>
              </li>
              <li class="nav-item">
                <a href="#" class="nav-link">
                  <i class="fas fa-th-list nav-icon green"></i>
                  <p>Manage Menu Item</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="#" class="nav-link">
                  <i class="fas fa-font nav-icon"></i>
                  <p>Manage Article</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="#" class="nav-link">
                  <i class="fas fa-file nav-icon yellow"></i>
                  <p>Manage File</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="#" class="nav-link">
                  <i class="far fa-image nav-icon teal"></i>
                  <p>Manage Gallery</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="#" class="nav-link">
                  <i class="fab fa-trade-federation nav-icon teal"></i>
                  <p>Manage Link</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="#" class="nav-link">
                  <i class="fab fa-facebook-messenger nav-icon blue"></i>
                  <p>Manage Feedback</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="#" class="nav-link">
                  <i class="fas fa-heart nav-icon red"></i>
                  <p>Manage Career</p>
                </a>
              </li>
              <li class="nav-item">
                <a href="#" class="nav-link">
                  <i class="fas fa-cog nav-icon cyan"></i>
                  <p>Setting</p>
                </a>
              </li>
            </ul>
      </nav>
      <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
  </aside>

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Main Content -->
    <div class="content">
      <div class="container-fluid">
        <router-view></router-view>

        <vue-progress-bar></vue-progress-bar>
      </div>
    </div>
  </div>
  <!-- Main Footer -->
  <footer class="main-footer">
    <!-- To the right -->
    <div class="float-right d-none d-sm-inline">
      Anything you want
    </div>
    <!-- Default to the left -->
    <strong>Copyright &copy; 2018-2019 <a href="http://www.ajaykumaryadav.ml" target="_blank">Ajay Kumar Yadav</a>.</strong> All rights reserved.
  </footer>
</div>
<!-- ./wrapper -->

@auth
<script>
  window.user = @json(auth()->user())
</script>
@endauth

<script src="/js/app.js"></script>
</body>
</html>
