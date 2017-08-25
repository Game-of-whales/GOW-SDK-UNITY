//
//  GWDefinition.h
//  gow
//
//  Created by Dmitry Burlakov on 26.09.16.
//  Copyright © 2016 GameOfWhales. All rights reserved.
//

#import <Foundation/Foundation.h>

/*!
 @brief Special offer definition
 */


@interface GWDefinition : NSObject
    /*!
     @brief Special offer identifier
     @return NSString special offer identifier
     */

    @property(nonatomic, readonly, nonnull) NSString *id;
    /*!
     @brief Special offer title
     @return NSString special offer title
     */
    @property(nonatomic, readonly, nullable) NSString *title;
    /*!
    @brief Special offer description
    @return NSString special offer description
    */
    @property(nonatomic, readonly, nullable) NSString *info;

    @property(nonatomic, readonly, nullable) NSDictionary *skus;
    /*!
    @brief When special offer was activated for user
    @return NSDate date of activation
    */
    @property(nonatomic, readonly, nullable) NSDate *activatedAt;
    /*!
    @brief When special offer will stop
    @return NSDate finish date
    */
    @property(nonatomic, readonly, nullable) NSDate *dateTo;
    @property(nonatomic, readonly, nullable) NSNumber *activation;
    /*!
    @brief When special offer will finish for current user
    @return NSDate finish date
    */
    @property(nonatomic, readonly, nullable) NSDate *finishAt;

    + (nonnull instancetype)definitionWithJson:(nullable NSDictionary *)json;

    - (nonnull instancetype)initWithJson:(nullable NSDictionary *)json;

    /*!
     @brief Is special offer expired for current moment
     @return BOOL YES, if special offer is expired
     */
    - (BOOL)isExpired;

    /*!
     @brief Is special offer active for current moment
     @return BOOL YES, if special offer is active
     */
    - (BOOL)isActive;

@end
