function UserDataEntry (props) {
    return ( 
      <div>
        {props.text}: <input type="text" id = {props.id}/>
      </div>
    );
  }

  export default UserDataEntry;