package co.com.bucompany.mascotapp.Core.Interfaces

import android.content.Context
import co.com.bucompany.mascotapp.Entidades.Request.LoginRequest

interface IVista {

    fun MostrarVentanaLogin(c: Context?)
    fun MostrarVentanaDashboard(c: Context?, lr:LoginRequest?)

}