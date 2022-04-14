import { useState } from 'react';

const initialUser = 
  { 
    name: "",
    surname: "",
    gender: "",
    address: "",
    email: "",
    username: "",
    password: ""
  }




function RegisterButton() {
    const [user, setUser] = useState(initialUser);
    const [listOfUsers, setListOfUsers] = useState([]);

    console.log(user);
    console.log(listOfUsers);

    return (
      <div>
        <button onClick={() => {setUser(
          { 
            name: document.getElementById("name").value,
            surname: document.getElementById("surname").value,
            address: document.getElementById("address").value,
            email: document.getElementById("email").value,
            username: document.getElementById("username").value,
            password: document.getElementById("password").value 
          }); setListOfUsers(oldListOfUsers => [...oldListOfUsers, user] );}}>
          Register (function)
        </button>
      </div>
    );
  }

export default RegisterButton;