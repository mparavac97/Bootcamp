import UserDataEntry from "./UserDataEntry";
import Gender from "./Gender";

function UserData (props) {
    return (
      <div>
        <UserDataEntry text={props.name} id="name"/>
        <UserDataEntry text={props.surname} id="surname"/>
        <Gender text={props.gender}/>
        <UserDataEntry text={props.address} id ="address"/>
      </div>
    );
  }

  export default UserData;