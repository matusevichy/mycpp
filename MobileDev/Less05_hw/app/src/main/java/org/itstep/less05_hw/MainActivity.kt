package org.itstep.less05_hw

import android.annotation.SuppressLint
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Adapter
import android.widget.AdapterView
import android.widget.Button
import android.widget.ListView
import android.widget.TextView
import kotlinx.coroutines.newFixedThreadPoolContext

class MainActivity : AppCompatActivity() {
    private val todos: MutableList<ToDo> = mutableListOf<ToDo>()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        var button = findViewById<Button>(R.id.AddButton)
        val listView = findViewById<ListView>(R.id.ToDoListView)
        val todoAdapter = ToDoAdapter(this, todos)
        listView.adapter = todoAdapter

        button.setOnClickListener {
            var textView = findViewById<TextView>(R.id.TextTextView)
            if (textView.text.toString() != "") {
                val id: Int
                if (todos.size == 0) id = 1
                else id = todos.maxOf { t -> t.id } + 1

                var todo:ToDo = ToDo( id, textView.text.toString())
                todos.add(todo)
                todoAdapter.notifyDataSetChanged()
                textView.text = ""
            }
        }

        listView.onItemLongClickListener =
            AdapterView.OnItemLongClickListener { parent, view, position, id ->
                todos.removeAt(position)
                todoAdapter.notifyDataSetChanged()
                true
            }
    }
}