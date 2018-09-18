package co.com.bucompany.mascotapp.Ui

import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import android.support.v7.app.AlertDialog
import android.view.View
import android.widget.ProgressBar
import android.widget.TextView
import co.com.bucompany.mascotapp.Core.Entorno
import co.com.bucompany.mascotapp.Core.Metodos.Metodos
import co.com.bucompany.mascotapp.R

class DashboardActivity : AppCompatActivity() {

    private var txttexto: TextView? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_dashboard)
        ShowCargando()
        txttexto = findViewById<View>(R.id.txtid) as TextView
        //txttexto!!.text = dato()
        //Metodos.toast(applicationContext, Entorno.getInstance().Vista.usuario?.response!!.Mensaje);

    }

    fun  dato() : String{
        var res : String = Entorno.getInstance().Vista.usuario!!.response!!.Mensaje.toString();
        return res;
    }

    fun ShowCargando(){
        val alertDialog = AlertDialog.Builder(this)
        val dialogoView = layoutInflater.inflate(R.layout.dialogo_cargando, null)
        val progressBar = dialogoView.findViewById<ProgressBar>(R.id.progressBar)
        if(progressBar != null){
            val visibility = if (progressBar.visibility == View.GONE) View.VISIBLE else View.GONE
            progressBar.visibility = visibility
        }
        alertDialog.setView(dialogoView)
        alertDialog.show()


    }


}
