import React, {useState} from 'react';
import './App.css';
import ToDoForm from './components/ToDoForm';
import ToDoList from './components/ToDoList';

function App() {
  let[list, updateToDoList] = useState([]);
  return (
    <div>
      <ToDoForm list={list} updateToDoList={updateToDoList}/>
      <ToDoList list={list}/>
    </div>
  );
}

export default App;