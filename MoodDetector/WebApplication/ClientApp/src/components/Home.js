import React, { Component } from 'react';

export class Home extends Component {
  displayName = Home.name

  render() {
      return (
          <div>
              <h1>Welcome to Mood Detector, please login:</h1>
              <label>Username: </label> <input type="text" />
              <label>Password: </label> <input type="text" />
              <button>Login</button>
          </div>
    );
  }
}
