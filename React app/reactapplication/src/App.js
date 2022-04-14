import './App.css';
import React from 'react';
import UserData from './UserData';
import AccountData from './AccountData';
import RegisterButton from './RegisterButton';
import Register from './Register';

function App() 
{
  return (
    <div id="root">
      <UserData name="Name" surname="Surname" gender="Choose gender" address="Address"/>
      <AccountData email="Email" username="Username" password="Password" confirmPassword="Confirm password" />
      <RegisterButton/>
      <Register />
    </div>
  );
}

export default App;
