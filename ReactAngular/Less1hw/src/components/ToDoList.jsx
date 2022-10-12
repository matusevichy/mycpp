import React from 'react';
import ToDoItem from './ToDoItem';

function ToDoList({list})
{
  return(
    <div class="todo-list">
      {list.map((item) => {
        return(
          <ToDoItem {...item} />
        );
      })}
    </div>
  );
}

export default ToDoList;