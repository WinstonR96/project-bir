package co.com.bucompany.mascotapp.Core.Solicitudes

import android.content.Context
import co.com.bucompany.mascotapp.Core.Enums.Triggers
import co.com.bucompany.mascotapp.Core.Interfaces.ISolicitud
import co.com.bucompany.mascotapp.Entidades.Request.LoginRequest

class SolVentanaDashboard(override var Trigger: Triggers, val Lr: LoginRequest, var c: Context) : ISolicitud {
}