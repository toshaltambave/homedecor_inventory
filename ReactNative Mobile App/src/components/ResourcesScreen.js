import React, { Component } from 'react';
import { ScrollView, TextInput, Text } from 'react-native';
import { List, ListItem, Button, FormLabel, FormInput, Card } from 'react-native-elements';
import axios from 'axios';

class ResourcesScreen extends Component {
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
  state = { facres: [] };

  componentWillMount() {
    const { navigation } = this.props;
    const rescode = navigation.getParam('fac_code', '1');
    console.log('got code: ', rescode);
    // const { navigation } = this.props;
    // const faccode = navigation.getParam('fac_code', '1');
    axios.get('https://7aba3qlnxa.execute-api.us-east-2.amazonaws.com/test/resource', {
        params: {
          key: rescode
        } })
      .then(response => {
        this.setState({ facres: response.data });
        console.log('res page', response.data);
  });
}

  render() {
    return (   
      <ScrollView>
        <List>
        <FormLabel>List Of Assigned Resources</FormLabel>
        { this.state.facres.map((userkey) => (
          
          <Card title={`${userkey.Resource_name}`}>
             
              
              <Text>{`Description: ${userkey.Resource_description}`}</Text>
              <Text>{`Color: ${userkey.Color}`}</Text>
              <Text>{`Size: ${userkey.Size}`}</Text>
              <Text>{`Quantity: ${userkey.Quantity}`}</Text>
              <Text>{`Resource code: ${userkey.Resource_code}`}</Text>
              <Button 
                raised 
                title='Edit'
                color='white'
                onPress={() => {
                  /* 1. Navigate to the Details route with params */
                  this.props.navigation.navigate('Edit', {
                    quant: userkey.Quantity,
                    name: userkey.Resource_name,
                    rescode: userkey.Resource_code,
                    desc: userkey.Resource_description,
                    facilitycode: userkey.Facility_code,
                    title: 'Edit'
                  });
                }}
                buttonStyle={{
                  backgroundColor: '#455a64',
                  width: 300,
                  height: 45,
                  borderColor: 'transparent',
                  borderWidth: 0,
                  borderRadius: 5
                }}
                containerStyle={{ marginTop: 20 }}
              />
          </Card>
        ))}
        </List>
      </ScrollView>
    );
  }
}

export default ResourcesScreen;
