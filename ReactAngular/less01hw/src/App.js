import logo from './logo.svg';
import {MusicGroup} from "./components/MusicGroup";
import GreatPerson from "./components/GreatPerson";
import './App.css';
import ColorChanger from "./components/ColorChanger";

function App() {
  return (
    <div className="App">
      <header className="App-header">
          <p>Ex. 1</p>
          <MusicGroup group={musicGroup} />
          <p>Ex. 2</p>
          <GreatPerson person={greatPerson} />
          <p>Ex. 3</p>
          <ColorChanger/>
      </header>
    </div>
  );
}

const musicGroup = {
    name: "Group 1",
    members: [ "member 1", "member 2", "member 3"],
    albums: ["album 1", "album 2", "album 3"],
    covers: ["cover 1", "cover 2", "cover 3"]
}

const greatPerson ={
    firstName: "Ivan",
    middleName: "Ivanovich",
    lastName: "Ivanov",
    birthDate: "23/02/1978",
    photo: "image",
    biography: "text"
}
export default App;
