function AccountDataEntry(props) {
    return (
      <div>
        {props.text}: <input type={props.inputType} id={props.id} />
      </div>
    );
  }

  export default AccountDataEntry;