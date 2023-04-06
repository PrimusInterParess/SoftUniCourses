
import './App.css';
import { useState } from 'react';

function App() {

  const [ageUser, setAgeUser] = useState();

  const [hobbies, setHobbies] = useState({
    hiking: false,
    riding: false,
    reading: false,
  });

  const [formvalues, setFormValues] = useState({
    username:'Pesho',
    creditCardNumber:'',
    occupation:'engeneering',
    gender:'male',
    bio:'',
  });

  const onSubmit = (e) => {
    e.preventDefault();
    console.log(formvalues)
  };

  const onChangeHalndler = (e) => {
    setFormValues(state=>({...state,[e.target.name]:e.target.value}))
  };

  const onAgeUserChange = (e) => {
    const number = Number(e.target.value);
    setAgeUser(number || null);
  };


  const onHobbiesChange = (e) => {
    console.log(hobbies);

    setHobbies(state => ({ ...state, [e.target.value]: e.target.checked })
    );
    console.log(e.target.value);
    console.log(e.target.checked);
    console.log(hobbies);
  };


  return (
    <div className="App">
      <header className="App-header">
        <form onSubmit={onSubmit}>
          <div>
            <label htmlFor="username">Username</label>
            <input
              type="text"
              name="username"
              value={formvalues.username}
              onChange={onChangeHalndler}
            />
          </div>
          <div>
            <label htmlFor="age">Age</label>
            <input
              type="number"
              name="age"
              value={ageUser ?? ''}
              onChange={onAgeUserChange}
            />
          </div>
          {
            ageUser >= 18 && (
              <div>
                <label htmlFor="credit-card">Credit card</label>
                <input
                  type="text"
                  name="credit-card"
                  value={formvalues.creditCardNumber}
                  onChange={onChangeHalndler}
                />
              </div>
            )
          }

          <div>
            <label htmlFor="ocupation">Ocupation</label>
            <select name="occupation" id="ocupation" value={formvalues.occupation} onChange={onChangeHalndler}>
              <option value="it">ICT</option>
              <option value="engineering">Engineering</option>
              <option value="qa">QA</option>
            </select>
          </div>

          <div>
            <label htmlFor="bio">Bio</label>
            <textarea name="bio" id="bio" cols="30" rows="10" value={formvalues.bio} onChange={onChangeHalndler}></textarea>
          </div>

          <div>
            <label htmlFor="male">Male</label>
            <input type="radio" name="gender" id="male" value="male" onChange={onChangeHalndler} checked={formvalues.gender === 'male'} />
            <label htmlFor="female">Female</label>
            <input type="radio" name="gender" id="female" value="female" onChange={onChangeHalndler} checked={formvalues.gender === 'female'} />
          </div>
         
          <div>
            <label htmlFor="hiking">hiking</label>
            <input type="checkbox" name="hobbies" id="hiking" value="hiking" onChange={onHobbiesChange} checked={hobbies["hiking"]} />
            <label htmlFor="reading">reading</label>

            <input type="checkbox" name="hobbies" id="reading" value="reading" onChange={onHobbiesChange} checked={hobbies["reading"]} />
            <label htmlFor="riding">riding</label>
            <input type="checkbox" name="hobbies" id="riding" value="riding" onChange={onHobbiesChange} checked={hobbies["riding"]} />
          </div>

          <button type='submit'>Send</button>
        </form>
      </header>
    </div>
  );
}

export default App;
