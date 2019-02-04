import React, { Component } from 'react';
import {
  StyleSheet,
  Text,
  View,
   Image 
} from 'react-native';


export default class Logo extends Component<{}> {
	render(){
		return(
			<View style={styles.container}>
				<Image  style={{width:200, height: 200}}
          			source={require('../../images/logo.jpg')}/>
          		<Text style={styles.logoText}>HomeDecor Management</Text>	
  			</View>
			)
	}
}

const styles = StyleSheet.create({
  container: {
    flexGrow: 1,
    marginVertical: 15,
    alignItems: 'center'
  },
  logoText: {
  	marginVertical: 15,
  	fontSize: 18,
  	color: 'rgba(255, 255, 255, 0.7)'
  }
});

