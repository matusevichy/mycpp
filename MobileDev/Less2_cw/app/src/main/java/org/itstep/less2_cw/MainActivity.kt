package org.itstep.less2_cw

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.EditText
import android.widget.TextView

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    fun buttonClick(view: View) {
        var editTex1: EditText = findViewById(R.id.editText1);
        var editTex2: EditText = findViewById(R.id.editText2);
        var textiew: TextView = findViewById(R.id.textView);
        var result: Int = editTex1.text.toString().toInt()+editTex2.text.toString().toInt();
        textiew.text=result.toString();
    }
}