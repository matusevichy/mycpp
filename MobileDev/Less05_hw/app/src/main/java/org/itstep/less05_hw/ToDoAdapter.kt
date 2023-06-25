package org.itstep.less05_hw

import android.content.Context
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ArrayAdapter
import android.widget.TextView

class ToDoAdapter (context: Context, todos: List<ToDo>): ArrayAdapter<ToDo>(context, 0, todos ) {
    override fun getView(position: Int, convertView: View?, parent: ViewGroup): View {
        return getDropDownView(position, convertView, parent)
    }

    override fun getDropDownView(position: Int, convertView: View?, parent: ViewGroup): View {
        val view: View
        view = LayoutInflater.from(context).inflate(R.layout.todo_item, parent, false)
        val todo = getItem(position)
        val todoNumber: TextView = view.findViewById(R.id.textViewNumber)
        val todoName: TextView = view.findViewById(R.id.textViewName)
        todo?.let {
            todoNumber.text = it.id.toString()
            todoName.text= it.text
        }
        return view
    }
}