import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { About } from './components/About';
import { LogIn } from './components/LogIn';
import { NewSession } from './components/Teacher/NewSession';
import { ViewSessions } from './components/Teacher/ViewSessions';
import { Learnings } from './components/Teacher/Learnings';
import { MyProfileTeacher } from './components/Teacher/MyProfileTeacher';
import { MyProfileAdmin } from './components/Admin/MyProfileAdmin';
import { LogOut } from './components/LogOut';
import { AddTeacher } from './components/Admin/AddTeacher';
import { EditDeleteTeachers } from './components/Admin/EditDeleteTeachers';
import { SendInfo } from './components/Admin/SendInfo';
import { ImportantInfo } from './components/Teacher/ImportantInfo';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <Layout>
        <Route exact path='/' component={About} />
        <Route exact path='/logIn' component={LogIn} />
        <Route exact path='/newSession' component={NewSession} />
        <Route exact path='/viewSessions' component={ViewSessions} />
        <Route exact path='/learnings' component={Learnings} />
        <Route exact path='/myProfileTeacher' component={MyProfileTeacher} />
        <Route exact path='/myProfileAdmin' component={MyProfileAdmin} />
        <Route exact path='/logOut' component={LogOut} />
        <Route exact path='/addTeacher' component={AddTeacher} />
        <Route exact path='/editDeleteTeachers' component={EditDeleteTeachers} />
        <Route exact path='/sendInfo' component={SendInfo} />
        <Route exact path='/importantInfo' component={ImportantInfo} />
      </Layout>
    );
  }
}