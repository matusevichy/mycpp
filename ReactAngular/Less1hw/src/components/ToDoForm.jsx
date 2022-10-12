import React, {useRef, useState} from 'react';

function ToDoForm({list, updateToDoList}){
  let [errors, updateErrors] = useState({name : "", priority : "", dateEnd : ""});
  let refName=useRef(null);
  let refPriority=useRef(null);
  let refDateEnd=useRef(null);
  let refStatus=useRef(null);

  let mostSave = true;
  const sendForm = (e) =>{
    e.preventDefault();

    let name=refName.current.value;
    let priority=refPriority.current.value;
    let dateEnd=refDateEnd.current.value;
    let status=refStatus.current.checked;

    let newErrors = {...errors};

    newErrors.name="";
    if(name == ""){
      mostSave=false;
      newErrors.name="Fill Name filed!"
    }

    newErrors.priority="";
    if(priority == ""){
      mostSave=false;
      newErrors.priority="Select priority!"
    }

    newErrors.dateEnd="";
    if(dateEnd == ""){
      mostSave=false;
      newErrors.dateEnd="Select date end!"
    }

    updateErrors(newErrors);
  	console.log(errors);
    if(mostSave){
      let newList=[...list];
      newList.push({name: name, priority: priority, dateEnd: dateEnd, status: status});
      updateToDoList(newList);
      refName.current.value = "";
      refPriority.current.value = "";
      refDateEnd.current.value = "";
      refStatus.current.checked = false;
    }
  }

  return(
    <div class="todo-form">
      <h3>Add new item</h3>
      <form onSubmit={sendForm}>
        <input class="name" type="text" name="name" ref={refName} placeholder="Name" />
        <span class="error">{errors.name}</span>
        <br/>
        <label>Priority
          <select class= "priority" name="priority" ref={refPriority} defaultValue="">
            <option disabled value="">--Select priority--</option>
            <option value="Low">Low</option>
            <option value="Medium">Medium</option>
            <option value="High">High</option>
          </select>
          <span class="error">{errors.priority}</span>
        </label>
        <br/>
        <label>Date end
          <input class="dateend" type="date" name="dateend" ref={refDateEnd} /> 
          <span class="error">{errors.dateEnd}</span>
        </label>
        <br/>
        <label>Status
          <input type="checkbox" name="status" ref={refStatus} />
        </label>
        <br/>
        <button name="btnSend" type="submit">Send</button>
      </form>
    </div>
  );
}

export default ToDoForm;