using UnityEngine;

public class DamageInfo
{
    // Usamos { get; } sin "set" para que sean de solo lectura después de creadas
    public float Cantidad { get; }
    public string TipoDeDanio { get; }

    // Constructor: La única forma de darle valores es al momento de crear el objeto
    public DamageInfo(float cantidad, string tipo)
    {
        this.Cantidad = cantidad;
        this.TipoDeDanio = tipo;
    }
}