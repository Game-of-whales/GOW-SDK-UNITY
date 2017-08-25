//
//  GWReplacement.h
//  gow
//
//  Created by Dmitry Burlakov on 26.09.16.
//  Copyright © 2016 GameOfWhales. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <StoreKit/StoreKit.h>

@class GWDefinition;

/*!
 @brief Replacement provide information about current special offers for user
*/
@interface GWReplacement : NSObject
    /*!
     @brief Special offer definition
     @return GWDefinition definition
     */
    @property(nonatomic, readonly, nonnull) GWDefinition *definition;
    /*!
     @brief Product identifier, contains new product id
     @return NSString Product identifier
     */
    @property(nonatomic, readonly, nonnull) NSString *productIdentifier;
    /*!
     @brief Returns StoreKit product definition
     @return SKProduct product description
     */
    @property(nonatomic, retain, nonnull) SKProduct *product;
    /*!
     @brief Returns price
     @return NSNumber product price
     */
    @property(nonatomic, copy, nonnull) NSNumber *price;
    /*!
     @brief Original product identifier
     @return NSString original product identifier
     */
    @property(nonatomic, readonly, nonnull) NSString *originalProductIdentifier;
    /*!
     @brief StoreKit original product definition
     @return SKProduct original product definition
     */
    @property(nonatomic, retain, nonnull) SKProduct *originalProduct;
    /*!
     @brief Original price
     @return NSNumber original product price
     */
    @property(nonatomic, copy, nonnull) NSNumber *originalPrice;

    + (nonnull instancetype)replacementWithDefinition:(nonnull GWDefinition *)definition originalProductIdentifier:(nonnull NSString *)originalSku productIdentifier:(nonnull NSString *)productIdentifier;

    - (nonnull instancetype)initWithDefinition:(nonnull GWDefinition *)definition originalProductIdentifier:(nonnull NSString *)originalProductIdentifier productIdentifier:(nonnull NSString *)productIdentifier;

@end
