import React, { Component } from 'react'
import OrderService from "../Services/OrderService";

class ListOrderComponent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            orders: []
        }
        this.addOrder = this.addOrder.bind(this);
    }

    addOrder(){
        this.props.history.push('/add-order/_add');
    }
    
    componentDidMount(){
        OrderService.getOrders().then((res) => {
            if(res.data==null)
            {
                this.props.history.push('/add-order/_add');
            }
            this.setState({ orders: res.data});
        });
    }
    render() {
        return (
            <div>
                <h2 className="text-center">Orders List</h2>
                <div className="row">
                    <button className="btn btn-primary" onClick={this.addOrder}>Add Order</button>
                </div>
                <br />
                <div className="row">
                    <table className="table table-striped table-bordered">
                        <thead>
                        <tr>
                            <th>Order ID</th>
                            <th>Sender City</th>
                            <th>Sender Address</th>
                            <th>Recipient City</th>
                            <th>Recipient Address</th>
                            <th>Weight</th>
                            <th>Pickup Date</th>
                        </tr>
                        </thead>
                        <tbody>
                        {
                            this.state.orders.map(order =>
                                <tr key={order.id}>
                                    <td>{order.id}</td>
                                    <td>{order.senderCity}</td>
                                    <td>{order.senderAddress}</td>
                                    <td>{order.recipientCity}</td>
                                    <td>{order.recipientAddress}</td>
                                    <td>{order.weight}</td>
                                    <td>{order.pickupDate}</td>
                                </tr>
                            )
                        }
                        </tbody>
                    </table>
                </div>
            </div>
        );
    }
}

export default ListOrderComponent