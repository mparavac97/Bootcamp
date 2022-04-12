import logo from './logo.svg';
import './App.css';
import React from 'react';
import ReactDOM from 'react-dom';

function App() 
{
  return (
    <div id="root">
      <UserData name="Name" surname="Surname" gender="Choose gender" address="Address"/>
      <AccountData email="Email" username="Username" password="Password" confirmPassword="Confirm password" />
      <RegisterButton/>
    </div>
  );
}


function UserDataEntry (props) {
  return ( 
    <div>
      {props.text}: <input type="text"/>
    </div>
  );
}

function Gender (props) {
  return (
    <div>
      {props.text}: <input type="radio" name="gender"/> M <input type="radio" name="gender"/> F
    </div>
  );
}

function UserData (props) {
  return (
    <div>
      <UserDataEntry text={props.name}/>
      <UserDataEntry text={props.surname}/>
      <Gender text={props.gender}/>
      <UserDataEntry text={props.address}/>
    </div>
  );
}

function AccountDataEntry(props) {
  return (
    <div>
      {props.text}: <input type={props.inputType}/>
    </div>
  );
}

function AccountData (props) {
  return (
    <div>
      <AccountDataEntry text={props.email} inputType="text"/>
      <AccountDataEntry text={props.username} inputType="text"/>
      <AccountDataEntry text={props.password} inputType="password"/>
      <AccountDataEntry text={props.confirmPassword} inputType="password"/>
    </div>
  );
}

function RegisterButton() {
  return (
    <button>Register</button>
  );
}

export default App;
