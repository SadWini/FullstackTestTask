import axios from 'axios';

const ORDER_API_BASE_URL = "http://localhost:5115/api/v1/Order";

class OrderService {

    getOrders(){
        return axios.get(ORDER_API_BASE_URL + '/' + 'findAll');
    }

    createOrder(order){
        return axios.post(ORDER_API_BASE_URL+ '/' + 'addOrder', order);
    }
}

export default new OrderService()