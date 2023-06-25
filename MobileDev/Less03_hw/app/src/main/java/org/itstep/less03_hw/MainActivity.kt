package org.itstep.less03_hw

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.widget.Button
import android.widget.CheckBox
import android.widget.EditText
import android.widget.RadioButton
import android.widget.RadioGroup
import android.widget.SeekBar
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity

const val RESULT_COUNT = "resultCount"
const val AGE_CONFORM = "ageConform"
const val ZP_CONFORM = "zpConform"

class MainActivity : AppCompatActivity() {

    private lateinit var pib: EditText
    private lateinit var age: EditText
    private lateinit var seekBarZP: SeekBar
    private lateinit var textViewSeek: TextView
    private lateinit var rg1: RadioGroup
    private lateinit var rg2: RadioGroup
    private lateinit var rg3: RadioGroup
    private lateinit var rg4: RadioGroup
    private lateinit var rg5: RadioGroup
    private lateinit var cbExpWork: CheckBox
    private lateinit var cbTeamork: CheckBox
    private lateinit var cbTrip: CheckBox
    private lateinit var button: Button

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        pib = findViewById(R.id.editTextPIB)
        age = findViewById(R.id.editTextAge)
        seekBarZP = findViewById(R.id.seekBarZP)
        textViewSeek = findViewById(R.id.textViewSeek)
        rg1 = findViewById(R.id.rG1)
        rg2 = findViewById(R.id.rG2)
        rg3 = findViewById(R.id.rG3)
        rg4 = findViewById(R.id.rG4)
        rg5 = findViewById(R.id.rG5)
        cbExpWork = findViewById(R.id.checkBoxExpWork)
        cbTeamork = findViewById(R.id.checkBoxTeamWork)
        cbTrip = findViewById(R.id.checkBoxTrip)
        button = findViewById(R.id.button)

        seekBarZP.setOnSeekBarChangeListener(object : SeekBar.OnSeekBarChangeListener{
            override fun onProgressChanged(seekBar: SeekBar?, progress: Int, fromUser: Boolean) {
                var pos = progress * (seekBar!!.width - 2 * seekBar.thumbOffset) / seekBar.max
                textViewSeek.text = ""+progress
                textViewSeek.x = seekBar.x+pos+seekBar.thumbOffset/2
            }

            override fun onStartTrackingTouch(seekBar: SeekBar?) {

            }

            override fun onStopTrackingTouch(seekBar: SeekBar?) {

            }
        })
        button.setOnClickListener{
            checkResut()
        }
    }

    private fun checkResut(){
        var isOk: Boolean = true
        if (pib.text.isEmpty()){
            isOk = false;
            pib.setError("Заповніть поле")
        }
        if (age.text.isEmpty()){
            isOk = false;
            age.setError("Вкажіть вік")
        }
        if (rg1.checkedRadioButtonId == -1){
            isOk = false;
            (rg1.getChildAt(0) as RadioButton).setError("Оберіть варіант відповіді")
        }
        else (rg1.getChildAt(0) as RadioButton).setError(null)

        if (rg2.checkedRadioButtonId == -1){
            isOk = false;
            (rg2.getChildAt(0) as RadioButton).setError("Оберіть варіант відповіді")
        }
        else (rg2.getChildAt(0) as RadioButton).setError(null)

        if (rg3.checkedRadioButtonId == -1){
            isOk = false;
            (rg3.getChildAt(0) as RadioButton).setError("Оберіть варіант відповіді")
        }
        else (rg3.getChildAt(0) as RadioButton).setError(null)

        if (rg4.checkedRadioButtonId == -1){
            isOk = false;
            (rg4.getChildAt(0) as RadioButton).setError("Оберіть варіант відповіді")
        }
        else (rg4.getChildAt(0) as RadioButton).setError(null)

        if (rg5.checkedRadioButtonId == -1){
            isOk = false;
            (rg5.getChildAt(0) as RadioButton).setError("Оберіть варіант відповіді")
        }
        else (rg5.getChildAt(0) as RadioButton).setError(null)

        var result: Int = calculateResult()
        val intent = Intent(this, ResultActivity::class.java)
        intent.putExtra(RESULT_COUNT, result)
        intent.putExtra(ZP_CONFORM, seekBarZP.progress in 800..1600)
        intent.putExtra(AGE_CONFORM, age.text.toString().toInt() in 21 .. 40)
        startActivity(intent)
    }

    private fun calculateResult(): Int {
        var result: Int = 0

        if (cbExpWork.isChecked) result+=2
        if (cbTeamork.isChecked) result++
        if (cbTrip.isChecked) result++
        if (rg1.checkedRadioButtonId == R.id.radioButton1_3) result+=2
        if (rg2.checkedRadioButtonId == R.id.radioButton2_1) result+=2
        if (rg3.checkedRadioButtonId == R.id.radioButton3_4) result+=2
        if (rg4.checkedRadioButtonId == R.id.radioButton4_2) result+=2
        if (rg5.checkedRadioButtonId == R.id.radioButton5_3) result+=2

        return result;
    }
}