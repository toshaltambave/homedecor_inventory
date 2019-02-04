import { StackNavigator } from 'react-navigation';
import LoginForm from './src/components/LoginForm';
import FacilitiesScreen from './src/components/FacilitiesScreen';

export const Appnav = StackNavigator({
    Login: { screen: LoginForm },
    Facility: { screen: FacilitiesScreen },
});

export default Appnav;
