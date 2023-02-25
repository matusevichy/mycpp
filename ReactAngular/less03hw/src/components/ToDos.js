import {useState} from "react";
import {ToDoForm} from "./ToDoForm";
import {ToDoList} from "./ToDoList";

const initToDoList=[];

export function ToDos(){
    const [toDoList, setToDoList] = useState(initToDoList);

    const addToDo = (name, closed) => {
        // console.log(name, state);
        setToDoList(prevState => {
            return [...prevState, {name, closed}];
        })
    }

    const setToDoState = (index, name, newClosed) =>{
        let closed = !newClosed;
        setToDoList(prevState => {
            prevState.splice(index,1,{name, closed})
            return [...prevState];
        });
    }

    const removeToDo = (index) =>{
        setToDoList(prevState => {
            // prevState.splice(index,1);
            console.log("removed", index, "element");
            return [...prevState.slice(0, index), ...prevState.slice(index+1)];
        })
    }
    return(<>
        <ToDoForm onAddToDo={addToDo}/>
        <ToDoList toDoList={toDoList} onSetToDoState={setToDoState} onRemove={removeToDo}/>
        </>
    )
}