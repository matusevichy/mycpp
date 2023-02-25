import {useState} from "react";

export function ToDoForm({onAddToDo}){
    const [name, setName] = useState('');
    const [closed, setState] = useState(false);

    const addHandler = (e) =>{
        // console.log(name,state);
        onAddToDo(name, closed);
        setName('');
        setState(false);
    }

    return(
        <div id='add-form'>
            <div>
                <input type='checkbox' name='todo-state' onChange={e => setState(e.target.checked)} checked={closed}/>
                <input name='todo-name' id='todo-name' placeholder='Input ToDo text' onChange={e => setName( e.target.value)} value={name}/>
            </div>
            <button onClick={addHandler}>Add</button>
        </div>
    )
}