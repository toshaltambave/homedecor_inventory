import React, { Component } from 'react';
import {
  Text,
  View,
  ScrollView,
  alert
} from 'react-native';
import axios from 'axios';
import { List, ListItem, FormLabel, Button } from 'react-native-elements';

class FacilitiesScreen extends Component {
    
    static navigationOptions = ({ navigation }) => ({
        title: `${navigation.state.params.title}`,
        
         headerTitleStyle: { textAlign: 'center', alignSelf: 'center' },
            headerStyle: {
                backgroundColor: '#455a64',
            },

            headerRight: (
                <Button
                  onPress={() => navigation.navigate('Login')}
                  title="Logout"
                  color="#fff"
                  buttonStyle={{
                    backgroundColor: '#718792',
                    width: 80,
                    height: 35,
                    borderColor: 'transparent',
                    borderWidth: 0,
                    borderRadius: 5
                  }}
                />
            ),   
        
        });
    
    
    state = { users: [] };
    
    
    componentWillMount() {
        const { navigation } = this.props;
        const userId1 = navigation.getParam('myemail', '1');
        axios.get('https://qybdp0dsia.execute-api.us-east-2.amazonaws.com/test/facility', {
            params: {
              key: userId1,
              
            } })
          .then(response => {
            this.setState({ users: response.data });
            console.log('login res facility page', this.state.users.Facility_Code);
      });
    }

    //   onLearnMore = (code) => {
    //     console.log('sending res code as :', code);
    //     this.props.navigation.navigate('Resource', { fac_code: code });
    //   };

    render() {
        
        return (
            
            <View>
                <ScrollView>
                    <List>
                    <FormLabel>List of Assigned Facilities </FormLabel>
                    {console.log(this.state.users)}   
                    { this.state.users.map((userkey) => (
                        <ListItem
                        scaleProps={{
                            friction: 90,
                            tension: 100,
                            activeScale: 0.95,
                          }}
                        key={userkey.Facility_code}
                        titleStyle={{ color: '#455a64', fontWeight: 'bold' }}
                        subtitleStyle={{ color: '#455a64' }}
                        title={`${userkey.Facility_name}`}
                        subtitle={`${userkey.Facility_code}`}
                        // onPress={() => {
                        //     this.props.navigation.navigate('Resource', {
                        //         fac_code: userkey.Facility_Code 
                        //     }); 
                        // }}
                        onPress={() => {
                            /* 1. Navigate to the Details route with params */
                            this.props.navigation.navigate('Resource', {
                              fac_code: userkey.Facility_code,
                              title: 'Resources'
                            });
                          }}
                        />
                    ))}
                    
                    </List>
                    
                </ScrollView>
               
            </View>
        );
    }
}

export default FacilitiesScreen;
