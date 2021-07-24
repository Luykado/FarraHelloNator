import React, { Component } from 'react';
import { Route, Switch } from 'react-router';
import { Layout } from './components/LayoutComponent/Layout';
import Welcome from './pages/WelcomePage/Welcome';
import SpecificOffer from './pages/SpecificOffer/SpecificOffer';
import CreateOffer from './pages/CreateOfferPage/CreateOffer'

// Initial 'clear' and variables
import './initial.css'

// Default classes for all components
import './defaults.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Switch>
        <Route exact path='/' component={Welcome} />
        <Route exact path='/create-offer' render={ () => { return (<Layout> <CreateOffer /> </Layout>) } } />
        <Route exact path='/offer' render={ () => { return (<Layout> <SpecificOffer /> </Layout>) } } />

      </Switch>
    );
  }
}
