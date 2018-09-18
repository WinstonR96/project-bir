package co.com.bucompany.mascotapp.Ui

import android.app.Activity
import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import co.com.bucompany.mascotapp.Core.Entorno
import co.com.bucompany.mascotapp.Core.Enums.Triggers
import co.com.bucompany.mascotapp.Core.Metodos.Metodos
import co.com.bucompany.mascotapp.Core.Reactor
import co.com.bucompany.mascotapp.Core.Solicitudes.SolVentanaDashboard
import co.com.bucompany.mascotapp.Entidades.Request.LoginRequest
import co.com.bucompany.mascotapp.R
import co.com.bucompany.mascotapp.Ui.Model.ModelVista
import com.google.gson.Gson

class LoginActivity : Activity() {

    //Declaro los widgets a utilizar
    private var usuario: EditText? = null
    private var password: EditText? = null
    private var login: Button? = null
    private var recuperar: TextView? = null
    private var registrar: TextView? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login)
        Entorno.getInstance().Vista =  ModelVista.getInstance()
        usuario = findViewById<View>(R.id.etUserLogin) as EditText
        password = findViewById<View>(R.id.etPasswordLogin) as EditText
        login = findViewById<View>(R.id.btLogIn) as Button
        recuperar = findViewById<View>(R.id.tvRecuperarPassword) as TextView
        registrar = findViewById<View>(R.id.tvRegistrarUser) as TextView
        login?.setOnClickListener(View.OnClickListener {
            if(usuario?.text.toString().isEmpty() || password?.text.toString().isEmpty()){
                Metodos.toast(applicationContext,"Rellene Campos Vacios")

            }else{
                //Invoco el metodo con la logica del login programada
                loginRequest();
            }
        })
    }


    private fun loginRequest(){
        var cadena : String ?= usuario?.text.toString()
        var user : String ?= null
        var email : String ?= null
        var contrasena : String = password?.text.toString()
        if(cadena!!.contains("@")){
            user = ""
            email = usuario?.text.toString()
        }else{
            user = usuario?.text.toString()
            email = ""
        }
        val LR : LoginRequest = LoginRequest(user,contrasena,email)
        //val json = Gson().toJson(LR)
        //Metodos.toast(applicationContext, json.toString())
        val solicitudDashobard : SolVentanaDashboard = SolVentanaDashboard(Triggers.VentanaDashboard,LR,this)
        Reactor.getInstance().ProcesarSolicitud(solicitudDashobard)

    }
}
