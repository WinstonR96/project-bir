package co.com.bucompany.mascotapp.Core.Interfaces

import android.content.Context
import co.com.bucompany.mascotapp.Entidades.Request.LoginRequest
import co.com.bucompany.mascotapp.Entidades.Response.LoginResponse

interface IVista{

    var usuario : IResultadoLogin?

    fun MostrarVentanaLogin(c: Context?)
    fun MostrarVentanaDashboard(c: Context?, lr:LoginRequest?)

}