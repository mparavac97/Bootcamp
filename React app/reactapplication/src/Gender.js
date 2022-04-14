function Gender (props) {
    return (
      <div>
        {props.text}: <input type="radio" name="gender"/> M <input type="radio" name="gender"/> F
      </div>
    );
  }

  export default Gender;