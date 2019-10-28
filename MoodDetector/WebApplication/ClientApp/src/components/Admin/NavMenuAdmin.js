import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';
import '../NavMenu.css';

export class NavMenuAdmin extends Component {
    displayName = NavMenuAdmin.name

    render() {
        return (
            <Navbar inverse fixedTop fluid collapseOnSelect>
                <Navbar.Header>
                    <Navbar.Brand>
                        <Link to={'/about'}>Mood Detector</Link>
                    </Navbar.Brand>
                    <Navbar.Toggle />
                </Navbar.Header>
                <Navbar.Collapse>
                    <Nav>
                        <LinkContainer to={'/addTeacher'} exact>
                            <NavItem>
                                <Glyphicon glyph='plus' /> Add Teacher
                            </NavItem>
                        </LinkContainer>
                        <LinkContainer to={'/editDeleteTeachers'} exact>
                            <NavItem>
                                <Glyphicon glyph='edit' /> Edit/Delete Teachers
                            </NavItem>
                        </LinkContainer>
                        <LinkContainer to={'/sendInfo'} exact>
                            <NavItem>
                                <Glyphicon glyph='envelope' /> Send Info
                            </NavItem>
                        </LinkContainer>
                        <LinkContainer to={'/myProfileAdmin'} exact>
                            <NavItem>
                                <Glyphicon glyph='user' /> My Profile
                            </NavItem>
                        </LinkContainer>
                        <LinkContainer to={'/logOut'} exact>
                            <NavItem>
                                <Glyphicon glyph='log-out' /> Log Out
                            </NavItem>
                        </LinkContainer>
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        );
    }
}
