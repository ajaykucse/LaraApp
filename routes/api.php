<?php

use Illuminate\Http\Request;

/*
|--------------------------------------------------------------------------
| API Routes
|--------------------------------------------------------------------------
|
| Here is where you can register API routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| is assigned the "api" middleware group. Enjoy building your API!
|
*/

Route::middleware('auth:api')->get('/user', function (Request $request) {
    return $request->user();
});

Route::apiResources(['users' => 'API\UserController']);
Route::apiResources(['menu' => 'API\MenuController']);
Route::get('findMenu', 'API\MenuController@search');
Route::put('isActiveMenu', 'API\MenuController@statusOne'); 
Route::put('isDeActiveMenu', 'API\MenuController@statusZero');
Route::get('profile', 'API\UserController@profile');
Route::get('findUser', 'API\UserController@search');
Route::get('profile', 'API\UserController@updateProfile');