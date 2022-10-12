import React from 'react';

function ToDoItem({name, priority, dateEnd, status}){
  return (
    <div class="todo-item">
      <h3 class="name">{name}</h3>
      <p class="priority">{priority}</p>
      <p class="dateEnd">{dateEnd}</p>
      <p class="status">{status? "Active" : "Not active"}</p>
    </div>
  );
}

export default ToDoItem;