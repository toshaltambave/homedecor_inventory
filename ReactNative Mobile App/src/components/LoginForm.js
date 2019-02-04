import React, { Component } from 'react';
import { Text,View } from 'react-native';
import axios from 'axios';
import { Button, Card, CardSection, Input, Spinner } from './common';
import Logo from './common/Logo';
// import { StackNavigator } from 'react-navigation';

class LoginForm extends Component {

  static navigationOptions = ({ navigation }) => ({
    title: `${'Team 2'}`,
     headerTitleStyle: { textAlign: 'center', alignSelf: 'center' },
        headerStyle: {
            backgroundColor: '#455a64',
        },
    });

  state = { email: '', password: '', error: '', loading: false, axios_response: [] };

  onButtonPress() {
      const { email, password } = this.state;

      this.setState({ error: '', loading: true });

      
      const postData = {
        'key': 'prachi.goel06@gmail.com'
      
      };
      
      const axiosConfig = {
        headers: {
            'Content-Type': 'application/json;charset=UTF-8',
            'Access-Control-Allow-Origin': '*',
        }
      };
      axios.interceptors.request.use(request => {
        console.log('Starting Request', request);
        return request;
      });
      axios.get('https://y5dodgeyj4.execute-api.us-east-2.amazonaws.com/dev/EmailVal', postData, axiosConfig)
      .then((response) => {
        this.setState({ axios_response: response.data });
        // this.onLoginSuccess();
        console.log('My Login Response 1 :', this.state.axios_response);
        
        // navigation.navigate('Facility', { user: this.state.axios_response.data.user.UserName });
        
        console.log('for start');
        console.log('length of response ', this.state.axios_response.user.length);
        console.log('given email: ', email);
        
        for (let i = 0; i < this.state.axios_response.user.length; i++) {
          
          if (this.state.axios_response.user[i].UserName === email && this.state.axios_response.user[i].UserPassword === password) {
                console.log('Found at ', i);
                return this.onLoginSuccess(this.state.axios_response.user[i].Email);
            }
          console.log(this.state.axios_response.user[i].UserName);    
      }
      return this.onLoginFail();
      })
      .catch((error) => {
        console.log(error);
      });
  }

  
  onLoginFail() {
    this.setState({ error: 'Authentication Failed', loading: false });
  }

  onLoginSuccess(email) {
      this.setState({
      email: '',
      password: '',
      loading: false,
      error: ''
    });
    const navigation = this.props.navigation;
    navigation.navigate('Facility', { myemail: email, title: 'Facilities' }); 
  }

  renderButton() {
    if (this.state.loading) {
      return <Spinner size="small" />;
    }

    return (
      <Button onPress={this.onButtonPress.bind(this)}>
        Log in
      </Button>
    );
  }

  render() {
    return (
      <View style={styles.container}>
        <Logo />
        <Card style={styles.cardStyle}>
          <CardSection style={styles.section}>
            <Input
              placeholder="username"
              label="Username"
              value={this.state.email}
              onChangeText={email => this.setState({ email })}
            />
          </CardSection>

          <CardSection>
            <Input
              secureTextEntry
              placeholder="password"
              label="Password"
              value={this.state.password}
              onChangeText={password => this.setState({ password })}
            />
          </CardSection>

          <Text style={styles.errorTextStyle}>
            {this.state.error}
          </Text>

          <CardSection>
            {this.renderButton()}
          </CardSection>
        </Card>
      </View>
    );
  }
}

const styles = {
  errorTextStyle: {
    fontSize: 20,
    alignSelf: 'center',
    color: 'red'
  },
   container: {
    backgroundColor: '#455a64',
    
  },
  cardStyle: {
    // backgroundColor: '#455a64',
    
    flexDirection: 'column',
    justifyContent: 'center',
    alignItems: 'center'
  },
  section: {
    backgroundColor: '#455a64',
    justifyContent: 'center'
  }
};


export default LoginForm;
