package co.com.bucompany.mascotapp.Entidades.Response

import co.com.bucompany.mascotapp.Entidades.Usuarios

class LoginResponse(
        val CodigoMensaje : String,
        val Mensaje : String,
        val usuario : Usuarios
)