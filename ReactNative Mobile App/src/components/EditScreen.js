import React, { Component } from 'react';
import { ScrollView, TextInput, Alert } from 'react-native';
import { List, ListItem, Button, FormLabel, FormInput } from 'react-native-elements';
import { Card, CardSection, Input, Spinner } from './common';
import axios from 'axios';

class EditScreen extends Component {
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
  state = { facres: [], temp: [], quantity: '', name: '', resourcecode: '', description: '' };

  componentWillMount() {
    const { navigation } = this.props;
    this.setState({ quantity: navigation.getParam('quant', '1') });
    this.setState({ name: navigation.getParam('name', '1') });
    this.setState({ resourcecode: navigation.getParam('rescode', '1') });
    this.setState({ description: navigation.getParam('desc', '1') });
    this.setState({ faccode: navigation.getParam('facilitycode', '1') });
    
    // const { navigation } = this.props;
    // const faccode = navigation.getParam('fac_code', '1');   
}
onButtonPress() {
    const { name, resourcecode, description, quantity } = this.state;
    axios.get('https://8ryx3f8860.execute-api.us-east-2.amazonaws.com/test/editresource', {
        params: {
            Quantity: quantity,
            Resource_name: name,
            Resource_description: description,
            Resource_code: resourcecode
        } })
      .then(response => {
        Alert.alert(
            'Resource Update',
            'Sucess !!',
            [
              
              { text: 'OK', onPress: () => {
                  this.props.navigation.navigate('Resource', {
                    fac_code: this.state.faccode,
                    title: 'Resource'
              });
            } }
            ],
            { cancelable: false }
          );
  })
  .catch((error) => {
    console.log(error);
    Alert.alert(
        'Resource Update',
        'Failed !!',
        [
          
          { text: 'OK', onPress: () => console.log('OK Pressed')},
        ],
        { cancelable: false }
      );
  });
}

  render() {
    return (   
      <ScrollView>
        <List>
            <FormLabel>Edit Resource</FormLabel>  
               
                <CardSection >
                    <Input
                    placeholder={this.state.name}
                    label="Name"
                    onChangeText={name => this.setState({ name })}
                    />
                </CardSection>
                <CardSection >
                    <Input
                    placeholder={`${this.state.resourcecode}`}
                    label="Resource Code"
                    onChangeText={resourcecode => this.setState({ resourcecode })}
                    />
                </CardSection>
                <CardSection >
                    <Input
                    placeholder={this.state.description}
                    label="Description"
                    onChangeText={description => this.setState({ description })}
                    />
                </CardSection>
                <CardSection >
                    <Input
                    placeholder={`${this.state.quantity}`}
                    label="Quantity"
                    onChangeText={quantity => this.setState({ quantity })}
                    />
                </CardSection>
                <Button
                    title='Save'
                    color='white'
                    onPress={this.onButtonPress.bind(this)}
                    buttonStyle={{
                        backgroundColor: '#455a64',
                        width: 300,
                        height: 45,
                        borderColor: 'transparent',
                        borderWidth: 0,
                        borderRadius: 5
                      }}
                />
        </List>
      </ScrollView>
    );
  }
  
}


export default EditScreen;
