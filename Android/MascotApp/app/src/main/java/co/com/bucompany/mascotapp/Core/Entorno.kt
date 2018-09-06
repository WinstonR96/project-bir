package co.com.bucompany.mascotapp.Core

import android.content.Context
import co.com.bucompany.mascotapp.Common.MyVolley
import co.com.bucompany.mascotapp.Core.Interfaces.IVista
import co.com.bucompany.mascotapp.Ui.Model.ModelVista

class Entorno {

    var Vista : IVista = ModelVista.getInstance()

    companion object {
        @Volatile
        private var INSTANCE: Entorno?= null
        fun getInstance() =
                INSTANCE ?: synchronized(this){
                    INSTANCE ?: Entorno()
                }
    }

}