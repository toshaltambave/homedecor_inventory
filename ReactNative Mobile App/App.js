import React from 'react';
import { StyleSheet, Text, View} from 'react-native';
import { Header, Button, Spinner } from './src/components/common';
import LoginForm from './src/components/LoginForm';
import { StackNavigator } from 'react-navigation';
import FacilitiesScreen from './src/components/FacilitiesScreen';
import ResourcesScreen from './src/components/ResourcesScreen';
import EditScreen from './src/components/EditScreen';

export default class App extends React.Component {
  
  
  render() {
    return (
      <View style={styles.container}>
      <RootStack />
        {/* <View>
          <Header headerText="Home" />
          <LoginForm/>
        </View> */}
     </View>
    );
  }
}
const RootStack = StackNavigator(
  { 
    Login: {
      screen: LoginForm,
    },
    Facility: {
      screen: FacilitiesScreen,
    },
    Resource: {
      screen: ResourcesScreen,
    },
    Edit: {
      screen: EditScreen
    } 
  },
  {
    initialRouteName: 'Login',
  }
);

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#fff',
    
  },
});

