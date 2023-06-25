package org.itstep.less02_hw

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.EditText
import android.widget.TextView
import java.lang.Math.ceil
import java.lang.Math.sqrt
import kotlin.math.pow

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    fun calculate(view: View){
        var diagonalET: EditText = findViewById(R.id.editTextDiagonal);
        var widthET: EditText = findViewById(R.id.editTextWidth);
        var heightET: EditText = findViewById(R.id.editTextHeight);
        var resultTV: TextView = findViewById(R.id.textViewResult);
        if (diagonalET.text.toString() != "" && widthET.text.toString() != "" && heightET.text.toString() != ""){
            var diagonal: Double = diagonalET.text.toString().toDouble();
            var width: Double = widthET.text.toString().toDouble();
            var height: Double = heightET.text.toString().toDouble();
            var dpi: Int = ceil(sqrt(width.pow(2) + height.pow(2))/diagonal).toInt();
            var dpiName: String = "";
            var sizeName: String = "";
            when(dpi){
                in 0..120 -> dpiName = "ldpi"
                in 120..160 -> dpiName = "mdpi"
                in 160..240 -> dpiName = "hdpi"
                in 240..320 -> dpiName = "xhdpi"
                in 320..480 -> dpiName = "xxhdpi"
                in 480..640 -> dpiName = "xxxhdpi"
            }
            when(diagonal){
                in 2.0..3.5 -> sizeName = "small"
                in 3.5..4.0 -> sizeName = "normal"
                in 4.0..7.0 -> sizeName = "large"
                in 7.0..10.0 -> sizeName = "xlarge"
            }
            resultTV.text = dpi.toString() + "dpi; " + dpiName + "; size : " + sizeName;
        }
    }
}