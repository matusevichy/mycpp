export function ToDoList({toDoList, onSetToDoState, onRemove}){

    return (
        <ul>
            {
                toDoList.map((toDo, index) =>
                    <div key={index}>
                        <input name='todo-state' id='todo-state' type='checkbox' checked={toDo.closed} onChange={e => onSetToDoState(index, toDo.name, toDo.closed)}/>
                        <span style={toDo.closed?{textDecoration :'line-through'}:{textDecoration : 'none'} }> {toDo.name} <button onClick={e => onRemove(index)}>X</button></span>
                    </div>
                )
            }
        </ul>
    );
}