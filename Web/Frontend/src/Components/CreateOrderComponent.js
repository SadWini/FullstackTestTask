import React, { Component } from 'react'
import OrderService from '../services/OrderService';

class CreateOrderComponent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            id: '',
            senderCity: '',
            senderAddress: '',
            recipientCity: '',
            recipientAddress: '',
            weight: '',
            pickupDate: '',
            errorMessage: ''
        };
        this.saveOrUpdateOrder = this.saveOrUpdateOrder.bind(this);
        this.cancel = this.cancel.bind(this);
    }

    saveOrUpdateOrder = (e) => {
        e.preventDefault();

        let order = {
            id: '',
            senderCity: this.state.senderCity,
            senderAddress: this.state.senderAddress,
            recipientCity: this.state.recipientCity,
            recipientAddress: this.state.recipientAddress,
            weight: this.state.weight,
            pickupDate: this.state.pickupDate,
            errorMessage: ''
        };
        console.log('order => ' + JSON.stringify(order));
        
            OrderService.createOrder(order).then(res => {
                this.props.history.push('/orders');
            },err => this.setState({errorMessage: err.message}));
    }

    handleInputChange = (event) => {
        const { name, value } = event.target;
        this.setState({ [name]: value });
    }
    
    cancel = (e) => {
        e.preventDefault();
        this.props.history.push('/orders');
    }
    render() {
        return (
            <div>
                <div className="container">
                    <div className="row">
                        <div className="col-md-6 offset-md-3">
                            <h3 className="text-center">Create Order</h3>
                            <form>
                                <div className="form-group">
                                    <label>Sender City</label>
                                    <input type="text" name="senderCity" className="form-control"
                                           value={this.state.senderCity} onChange={this.handleInputChange} required />
                                </div>
                                <div className="form-group">
                                    <label>Sender Address</label>
                                    <input type="text" name="senderAddress" className="form-control"
                                           value={this.state.senderAddress} onChange={this.handleInputChange} required />
                                </div>
                                <div className="form-group">
                                    <label>Recipient City</label>
                                    <input type="text" name="recipientCity" className="form-control"
                                           value={this.state.recipientCity} onChange={this.handleInputChange} required />
                                </div>
                                <div className="form-group">
                                    <label>Recipient Address</label>
                                    <input type="text" name="recipientAddress" className="form-control"
                                           value={this.state.recipientAddress} onChange={this.handleInputChange} required />
                                </div>
                                <div className="form-group">
                                    <label>Weight</label>
                                    <input type="number" name="weight" className="form-control"
                                           value={this.state.weight} onChange={this.handleInputChange} required />
                                </div>
                                <div className="form-group">
                                    <label>Pickup Date</label>
                                    <input type="datetime-local" name="pickupDate" className="form-control"
                                           value={this.state.pickupDate} onChange={this.handleInputChange} required />
                                </div>

                                <button className="btn btn-success" onClick={this.saveOrUpdateOrder}>Save</button>
                                <button className="btn btn-danger" onClick={this.cancel} style={{ marginLeft: "10px" }}>Cancel</button>

                                { this.state.errorMessage &&
                                    <h5 className="alert alert-danger">
                                        { this.state.errorMessage } </h5> }
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}

export default CreateOrderComponent;
