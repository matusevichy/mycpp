package org.itstep.less03_hw

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.TextView

class ResultActivity : AppCompatActivity() {

    private lateinit var resultTextView: TextView
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_result)
        var textViewText: String = ""
        val result = intent.getIntExtra(RESULT_COUNT, 0)
        val ageConform = intent.getBooleanExtra(AGE_CONFORM, false)
        val zpConform = intent.getBooleanExtra(ZP_CONFORM, false)
        if (!ageConform){
            textViewText += "Ваш вік не відповідає вимогам компанії \n"
        }
        if (!zpConform){
            textViewText += "Ваш бажаний рівень заробітної плати не відповідає позиції компанії\n"
        }
        if (!ageConform || ! zpConform){
            textViewText += "Тест не пройдено"
        }
        else {
            Log.i("result", result.toString())
            val resultText = if (result >= 10) "Тест пройдено" else "Тест не пройдено"
            textViewText += "За результатами тесту ви набрали $result балів \n" + resultText
        }
        resultTextView = findViewById(R.id.textViewResult)
        resultTextView.text = textViewText
    }
}