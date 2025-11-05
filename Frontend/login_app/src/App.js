import React, { useState } from "react";
import './App.css';
import LoginForm from './LoginForm';
import LoginAttemptList from './LoginAttemptList';

const App = () => {
  const [loginAttempts, setLoginAttempts] = useState([]);

  return (
    <div className="App">
<<<<<<< HEAD
      <LoginForm onSubmit={({ login, password }) => console.log({ login, password })} />
=======
      <LoginForm onSubmit={({ login, password }) => {
        setLoginAttempts((prevAttempts) => [
          ...prevAttempts,
          { login, password, timestamp: new Date().toISOString() },
        ]);
      }} />
>>>>>>> 25d79f0 (Completed DeveloperSample assessment: frontend and backend)
      <LoginAttemptList attempts={loginAttempts} />
    </div>
  );
};

export default App;
