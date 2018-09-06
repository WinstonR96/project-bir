package co.com.bucompany.mascotapp.Core.Metodos

import android.app.Activity
import android.content.Context
import android.widget.Toast

class Metodos {
    companion object {
        fun toast(context: Context, setToast: CharSequence) {
            Toast.makeText(context, setToast, Toast.LENGTH_SHORT).show()
        }
    }

}