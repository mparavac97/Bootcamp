import AccountDataEntry from "./AccountDataEntry";

function AccountData (props) {
    return (
      <div>
        <AccountDataEntry text={props.email} inputType="text" id="email"/>
        <AccountDataEntry text={props.username} inputType="text" id="username"/>
        <AccountDataEntry text={props.password} inputType="password" id="password"/>
        <AccountDataEntry text={props.confirmPassword} inputType="password"/>
      </div>
    );
  }

  export default AccountData;