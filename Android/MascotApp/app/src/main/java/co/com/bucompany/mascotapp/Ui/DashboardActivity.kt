package co.com.bucompany.mascotapp.Ui

import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import co.com.bucompany.mascotapp.Core.Entorno
import co.com.bucompany.mascotapp.Core.Metodos.Metodos
import co.com.bucompany.mascotapp.R

class DashboardActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_dashboard)
        //Metodos.toast(applicationContext, Entorno.getInstance().Vista.Usuarios.Response?.usuario.toString())
    }
}
