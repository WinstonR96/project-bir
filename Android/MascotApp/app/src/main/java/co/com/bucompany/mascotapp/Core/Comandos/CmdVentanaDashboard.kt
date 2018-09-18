package co.com.bucompany.mascotapp.Core.Comandos

import android.content.Context
import android.content.Intent
import android.util.Log
import co.com.bucompany.mascotapp.Common.Constantes
import co.com.bucompany.mascotapp.Common.MyVolley
import co.com.bucompany.mascotapp.Core.Entorno
import co.com.bucompany.mascotapp.Core.Interfaces.ISolicitud
import co.com.bucompany.mascotapp.Core.Metodos.Metodos
import co.com.bucompany.mascotapp.Core.Solicitudes.SolVentanaDashboard
import co.com.bucompany.mascotapp.Entidades.Response.LoginResponse
import co.com.bucompany.mascotapp.Ui.DashboardActivity
import com.android.volley.Request
import com.android.volley.Response
import com.android.volley.toolbox.JsonObjectRequest
import com.google.gson.Gson
import org.json.JSONObject

class CmdVentanaDashboard: ComandoAbstract {
    var solventanadashboard : SolVentanaDashboard ?= null

    constructor(solicitud : ISolicitud) : super(solicitud){
        solventanadashboard = solicitud as SolVentanaDashboard
    }

    override fun Ejecutar() {
        var jsonobj = JSONObject()
        jsonobj.put("Usuario", solventanadashboard!!.Lr.Usuario.toString())
        jsonobj.put("Contrasena", solventanadashboard!!.Lr.Contrasena.toString())
        jsonobj.put("Email", solventanadashboard!!.Lr.toString())
        val queue = MyVolley.getInstance(solventanadashboard!!.c!!).requestQueue

        val request = JsonObjectRequest(Request.Method.POST, Constantes.Value.login, jsonobj,
                Response.Listener {
                    response ->
                    var gson = Gson()
                    var loginresponse : LoginResponse = gson?.fromJson(response.toString(), LoginResponse::class.java)
                    Log.i("Request",loginresponse.CodigoMensaje.toString())
                    Log.i("Request",loginresponse.Mensaje.toString())
                    if(loginresponse.CodigoMensaje == "01"){
                        Log.i("Request",loginresponse.usuario.toString())
                        Entorno.getInstance().Vista.usuario?.response = loginresponse
                        Entorno.getInstance().Vista!!.MostrarVentanaDashboard(solventanadashboard?.c, solventanadashboard?.Lr)

                    }
                    if(loginresponse.CodigoMensaje == "02"){
                        Metodos.toast(solventanadashboard!!.c!!, loginresponse.Mensaje)
                    }

                    if (loginresponse.CodigoMensaje == "0"){
                        Metodos.toast(solventanadashboard!!.c!!, loginresponse.Mensaje)
                    }

                    if(loginresponse.CodigoMensaje == "3"){
                        Metodos.toast(solventanadashboard!!.c!!, loginresponse.Mensaje.toString())
                    }

                },
                Response.ErrorListener {
                    error->
                    Log.i("Request Login error", error.toString())
                    Metodos.toast(solventanadashboard!!.c!!,error.toString())
                })

        MyVolley.getInstance(solventanadashboard!!.c!!).addToRequestQueue(request)

    }
}