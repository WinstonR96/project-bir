package co.com.bucompany.mascotapp.Ui.Model

import android.content.Context
import android.content.Intent
import android.support.v4.content.ContextCompat.startActivity
import android.util.Log
import co.com.bucompany.mascotapp.Common.Constantes
import co.com.bucompany.mascotapp.Common.MyVolley
import co.com.bucompany.mascotapp.Core.Entorno
import co.com.bucompany.mascotapp.Core.Interfaces.IResultadoLogin
import co.com.bucompany.mascotapp.Core.Interfaces.IVista
import co.com.bucompany.mascotapp.Core.Metodos.Metodos
import co.com.bucompany.mascotapp.Entidades.Request.LoginRequest
import co.com.bucompany.mascotapp.Entidades.Response.LoginResponse
import co.com.bucompany.mascotapp.Entidades.Usuarios
import co.com.bucompany.mascotapp.Ui.DashboardActivity
import co.com.bucompany.mascotapp.Ui.LoginActivity
import com.android.volley.Request
import com.android.volley.Response
import com.android.volley.toolbox.JsonObjectRequest
import com.google.gson.Gson
import com.google.gson.JsonObject
import org.json.JSONObject

class ModelVista: IVista {
    override val Usuarios : IResultadoLogin = ModelResultadoLogin.getInstance()

    companion object {
        @Volatile
        private var INSTANCE: ModelVista?= null
        fun getInstance() =
                INSTANCE ?: synchronized(this){
                    INSTANCE ?: ModelVista()
                }
    }



    override fun MostrarVentanaDashboard(c: Context?, lr:LoginRequest?) {
        val intent = Intent(c, DashboardActivity::class.java)
        //startActivity(c!!, intent, null)
        c!!.startActivity(intent)


    }


    override fun MostrarVentanaLogin(c: Context?){
        val intent = Intent(c, LoginActivity::class.java)
        startActivity(c!!.applicationContext,intent,null)
    }


}


