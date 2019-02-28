<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Notifications\Notifiable;
class Menu extends Model
{
	protected $table = 'menus';

    protected $fillable = [
    	'name',
    	'isActive'
    ];
}
