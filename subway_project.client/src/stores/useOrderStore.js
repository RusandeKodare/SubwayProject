import { defineStore } from 'pinia'
import { v4 as uuidv4 } from 'uuid';

export const useOrderStore = defineStore('order', {
  state: () => ({
    order: {
      takeAway: false,
      totalPrice: 0,
      products: [],
      subs: [],
      customerId: uuidv4(),
    }
  }),

  actions: {
    addProduct(product){
        this.order.products.push(product);
        this.order.totalPrice += product.price;
        console.log('PINIA: price added: ', product.price, 'new total: ', this.order.totalPrice)
        console.log('PINIA: added product', product, 'to order:', this.order.products)
    },

    removeProduct(product){
        const index = this.order.products.findIndex(p => p.id === product.id);
        if (index !== -1) {
            this.order.products.splice(index, 1);
            this.order.totalPrice -= product.price;
            console.log('PINIA: removed price: ', product.price, 'new total: ', this.order.totalPrice)
            console.log('PINIA: removed product', product, 'from order:', this.order.products)
        } else {
            console.log('PINIA: product not found in order:', product)
        }
    },

    changeTakeAway(boolean){
        this.order.takeAway = boolean;
        console.log('PINIA: changed take away to:', boolean)
        console.log('Total price', this.order.totalPrice)
    },

    addToTotalPrice(price){
        this.order.totalPrice += price;
        console.log('PINIA: price added: ', price, 'new total: ', this.order.totalPrice)
    },

    resetOrder(){
        this.order = {
            takeAway: false,
            totalPrice: 0,
            products: [],
            customerId: uuidv4(),
        }
        console.log('PINIA: order has been reset')
    }
  }
})
